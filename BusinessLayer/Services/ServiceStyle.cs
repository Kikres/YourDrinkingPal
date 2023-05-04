﻿using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceStyle
{
    private readonly IMapper _mapper;
    private readonly IRepositoryStyle _repositoryStyle;

    public ServiceStyle(IMapper mapper, IRepositoryStyle repositoryStyle)
    {
        _mapper = mapper;
        _repositoryStyle = repositoryStyle;
    }

    //Fetch
    public List<StyleDto> GetAll() => _mapper.Map<List<Style>, List<StyleDto>>(_repositoryStyle.GetAll(new QueryParamStyle(false)));

    public List<StyleDto> Take(int amount)
    {
        var objs = _repositoryStyle.GetAll(new QueryParamStyle(true)).Take(amount).ToList();
        return _mapper.Map<List<Style>, List<StyleDto>>(objs);
    }

    public StyleDto? GetById(int id)
    {
        var obj = _repositoryStyle.GetById(id, new QueryParamStyle(true));
        return _mapper.Map<Style?, StyleDto>(obj);
    }

    //public ClientDto GetByName(string name) => _mapper.Map<Client?, ClientDto>(_repositoryClient.GetByName(name, new QueryParamClient()));

    ////Manipulate
    //public ClientDto Create(ClientCreateDto dto) => _mapper.Map<Client, ClientDto>(_repositoryClient.Create(_mapper.Map<ClientCreateDto, Client>(dto)));

    //public bool Delete(int clientId) => _repositoryClient.Delete(_repositoryClient.GetById(clientId, new QueryParamClient())) + _repositoryContract.Delete(_repositoryContract.GetAllByClient(clientId, new QueryParamConract())) > 0;

    //public bool Update(ClientUpdateDto dto)
    //{
    //    var client = _repositoryClient.GetById(dto.Id, new QueryParamClient(true));

    //    //Solved like this due to nullable int
    //    if (dto.OrganizationId == null) dto.OrganizationId = client.OrganizationId;

    //    return _repositoryClient.Update(_mapper.Map(dto, client)) > 0;
    //}

    ////Check
    //public bool ClientExists(int id) => _repositoryClient.GetById(id, new QueryParamClient()) != null;
}