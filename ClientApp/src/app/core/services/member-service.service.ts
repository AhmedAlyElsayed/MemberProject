import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ObjectResponse } from '../models/Responsedto/ObjectResponse';
import { GridView } from '../models/grid/gridview';

@Injectable({
  providedIn: 'root'
})
export class MemberServiceService {
  query: string = "";
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  GetMembers(pageIndex?: number, pageSize?: number) {
    this.query = "";
    this.query = pageIndex ? `?pageIndex=${pageIndex}` : this.query;
    this.query =
      pageIndex && pageSize
        ? `${this.query}&pageSize=${pageSize}`
        : pageSize
          ? `?pageSize=${pageSize}`
          : "";

    return this.http.get<ObjectResponse>(this.baseUrl + `api/Member/GetMember` + this.query)
      .pipe(
        map(
          members => {
            if (members) {
              let UsersData: ObjectResponse = <ObjectResponse>members;
              if (UsersData.isPassed) {
                let gridViewData: GridView = <GridView>UsersData.data;

                return gridViewData;
              }

              return null;
            }
          }));
  }

  AddMember(name: string) {
    return this.http.post<ObjectResponse>(this.baseUrl + `api/Member/AddMember`, { name })
      .pipe(
        map(
          members => {
            if (members) {
              return members;
            }
          }));
  }

  RemoveMember(id: number) {
    return this.http.post<ObjectResponse>(this.baseUrl + `api/Member/RemoveMember?Id=`+ id, null)
      .pipe(
        map(
          members => {
            if (members) {
              return members;
            }
          }));
  }
}
