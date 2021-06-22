using AutoMapper;
using MemberProject.Common.Interfaces;
using MemberProject.DTO.Members;
using MemberProject.Models;
using MemberProject.Repository.Members;
using MemberProject.Services.Generic;
using MemberProject.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MemberProject.Services.Members
{
    public class MemberService : GService<MemberDto, Member, IMemberRepository>, IMemberService
    {
        private readonly IUnitOfWork<MemberdbContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMemberRepository genericRepository;

        public MemberService(IMemberRepository genericRepository, IUnitOfWork<MemberdbContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper) 
            : base(genericRepository, mapper)
        {
            this.genericRepository = genericRepository;
            this._unitOfWork = unitOfWork;
            this._response = responseDTO;
        }

        public override async ValueTask<IResponseDTO> AddAsync(MemberDto memberDto)
        {
            try
            {
                if (memberDto != null)
                {
                    var memberIsExists = await genericRepository.GetFirstAsync(x => x.Name.Trim() == memberDto.Name.Trim() && x.IsActive == true);
                    if (memberIsExists == null)
                    {
                        memberDto.IsActive = true;
                        var member = _mapper.Map<Member>(memberDto);
                        var addedItem = genericRepository.Add(member);

                        int save = await _unitOfWork.CommitAsync();

                        if (save > 0)
                        {
                            _response.Data = _mapper.Map<MemberDto>(addedItem);
                            _response.IsPassed = true;
                            _response.Message = "Ok";
                        }
                        else
                        {
                            _response.Data = null;
                            _response.IsPassed = false;
                            _response.Message = "Not saved";
                        }
                    }
                    else
                    {
                        _response.Data = null;
                        _response.IsPassed = false;
                        _response.Message = "Member is exist";
                    }
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Member not correct";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }


            return _response;
        }

        public override IResponseDTO Remove(MemberDto memberDto)
        {
            try
            {
                if (memberDto != null)
                {
                    var memberIsExists = genericRepository.GetFirst(x => x.Id == memberDto.Id && x.IsActive == true);
                    if (memberIsExists != null)
                    {
                        memberIsExists.IsActive = false;

                        var entityEntry = genericRepository.Update(memberIsExists);


                        int save = _unitOfWork.Commit();

                        if (save > 0)
                        {
                            _response.Data = memberDto;
                            _response.IsPassed = true;
                            _response.Message = "Ok";
                        }
                        else
                        {
                            _response.Data = null;
                            _response.IsPassed = false;
                            _response.Message = "Not saved";
                        }
                    }
                    else
                    {
                        _response.Data = null;
                        _response.IsPassed = false;
                        _response.Message = "Member not found";
                    }
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Member not correct";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;
        }

        public IResponseDTO GetAll(int? pageIndex = null, int? pageSize = null, MemberFilterDto filterDto = null)
        {
            IQueryable<Member> query = null;

            try
            {
                query = genericRepository.GetAll()
                                    .Where(c => c.IsActive == true);

                if (filterDto != null)
                {
                    if (!string.IsNullOrEmpty(filterDto.Name))
                    {
                        query = query.Where(x => x.Name.Trim().ToLower().Contains(filterDto.Name.Trim().ToLower()));
                    }
                }

                query = query.OrderByDescending(x => x.Id);

                var total = query.Count();

                //Check Sort Property
                if (filterDto != null && !string.IsNullOrEmpty(filterDto.SortProperty))
                {
                    query = query.OrderBy(
                        string.Format("{0} {1}", filterDto.SortProperty, filterDto.IsAscending ? "ASC" : "DESC"));
                }

                //Apply Pagination
                if (pageIndex.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }

                var dataList = _mapper.Map<List<MemberDto>>(query.ToList());

                _response.Data = new
                {
                    List = dataList,
                    Page = pageIndex ?? 0,
                    pageSize = pageSize ?? 0,
                    Total = total,
                    Pages = pageSize.HasValue && pageSize.Value > 0 ? total / pageSize : 1
                };


                _response.Message = "Ok";
                _response.IsPassed = true;
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.Message = "Error " + ex.Message;
                _response.IsPassed = false;
            }

            return _response;
        }
    }
}
