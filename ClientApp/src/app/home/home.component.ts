import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as swalFunctions from "../core/customLayout/message/sweet-alerts";

import { Member } from '../core/models/members/member';
import { IPageInfo } from '../core/models/page/IPageInfo';
import { MemberServiceService } from '../core/services/member-service.service';
import { NotificationService } from '../core/services/notifications/notification-service.service';

import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  swal = swalFunctions;
  public ColumnMode = ColumnMode;
  pager: IPageInfo;
  members: Member[];
  addMember: FormGroup;
  loadingIndicator: boolean;

  constructor(private membersService: MemberServiceService, private notifyService: NotificationService, private modalService: NgbModal, private fb: FormBuilder) {
  }

  ngOnInit() {
    this.pager = {
      page: 1,
      pages: 0,
      pageSize: 10,
      total: 0,
    };

    this.BuildDataGrid(this.pager.page, this.pager.pageSize);
    this.buildForm();
  }

  resetPager() {
    this.pager.page = 1;
    this.pager.pageSize = 10;
  }

  setPage(event) {
    this.pager.page = event.offset + 1;
    //if (this.isFilterHasValue())
    //  this.BuildDataGrid(this.unitFilter, this.pager.page, this.pager.pageSize);
    this.BuildDataGrid(this.pager.page, this.pager.pageSize);
  }

  onPageSizeChanged() {
    this.pager.page = 1;
    this.BuildDataGrid(this.pager.page, this.pager.pageSize);
  }

  BuildDataGrid(pageindex?: number, pageSize?: number) {
    this.loadingIndicator = true;
    this.membersService.GetMembers(pageindex, pageSize).subscribe(
      (response) => {
        if (response) {
          this.members = <Member[]>(response.list);
          this.pager.page = response.page;
          this.pager.pageSize = response.pageSize;
          this.pager.total = response.total;
          this.pager.pages = response.pages;
        }
      },
      (error) => {
        this.notifyService.showError(error, "Member");
      },
      () => {
        this.loadingIndicator = false;
      }
    );
  }

  buildForm(): void {
    this.addMember = this.fb.group({
      name: ['', [Validators.required]]});
  }

  newMember(modalName, event) {
    event.target.parentElement.parentElement.parentElement.blur();

    this.addMember.reset();
    this.modalService.open(modalName, {
      ariaLabelledBy: 'modal-basic-title',
      windowClass: "modal-holder",
      backdropClass: "light-blue-backdrop",
      centered: true,
      keyboard: false,
      backdrop: "static",
      size: "md",
    });
  }

  onSubmit(event) {
    event.preventDefault();
    if (this.addMember.valid) {
      this.membersService.
        AddMember(this.addMember.value.name)
        .subscribe(
          (response) => {
            if (response) {
              if (response.isPassed) {
                this.BuildDataGrid(this.pager.page, this.pager.pageSize);

                this.closeModal();

                this.notifyService.showSuccess("Added Successfully", "Member");
              } else {
                this.notifyService.showWarning(response.message, "Member");
              }
            }
          },
          (error) => {
            this.notifyService.showError(error, "Member");
          },
          () => {
          }
        );
    }
  }

  closeModal() {
    this.modalService.dismissAll();
  }

  onActiveSubmit(Id, event) {
    event.preventDefault();
    if (Id) {
      this.swal
        .ConfirmMessage(`Are You Sure To Delete This Member?`, 'Delete')
        .then(this.disActiveUser.bind(this, Id));
    }
  }

  disActiveUser(Id, isConfirm) {
    if (isConfirm.value) {
      this.membersService.
        RemoveMember(Id)
        .subscribe(
          (response) => {
            if (response) {
              if (response.isPassed) {
                this.BuildDataGrid(this.pager.page, this.pager.pageSize);

                this.notifyService.showSuccess("Deleted", "Member");
              } else {
                this.notifyService.showWarning(response.message, "Member");
              }
            }
          },
          (error) => {
            this.notifyService.showError(error, "Member");
          },
          () => {
          }
        );
    }
  }
}
