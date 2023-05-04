using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceInstruction
{
    private readonly IMapper _mapper;
    private readonly IRepositoryInstruction _repositoryInstruction;

    public ServiceInstruction(IMapper mapper, IRepositoryInstruction repositoryInstruction)
    {
        _mapper = mapper;
        _repositoryInstruction = repositoryInstruction;
    }

    //Fetch
    public List<InstructionDto> GetAll() => _mapper.Map<List<Instruction>, List<InstructionDto>>(_repositoryInstruction.GetAll(new QueryParamInstruction(false)));

    public List<InstructionDto> Take(int amount)
    {
        var instructions = _repositoryInstruction.GetAll(new QueryParamInstruction(true)).Take(amount).ToList();
        return _mapper.Map<List<Instruction>, List<InstructionDto>>(instructions);
    }

    public InstructionDto? GetById(int id)
    {
        var instruction = _repositoryInstruction.GetById(id, new QueryParamInstruction(true));
        return _mapper.Map<Instruction?, InstructionDto>(instruction);
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