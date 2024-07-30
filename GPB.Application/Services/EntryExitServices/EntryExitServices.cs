using GPB.Application.Dtos.EntryExitDto;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.Application.Services.EntryExitServices
{
    public class EntryExitServices : IEntryExitServices
    {
        private readonly IRepository<EntryExit> _repository;

        public EntryExitServices(IRepository<EntryExit> repository)
        {
            _repository = repository;
        }

        public async Task CreateEntryExitAsync(CreateEntryExitDto model)
        {
            var entryExit = new EntryExit
            {
                EntryExitId = model.EntryExitId,
                ReservationId = model.ReservationId,
                EntryTime = model.EntryTime,
                ExitTime = model.ExitTime,
                Status = model.Status,
                CreationDate = model.CreationDate,
                UpdateDate = model.UpdateDate,
            };

            await _repository.CreateAsync(entryExit);
        }

        public async Task DeleteEntryExitAsync(int entryexitId)
        {
            var entryExit = await _repository.GetByIdAsync(entryexitId);

            await _repository.DeleteAsync(entryExit);
        }

        public async Task<List<ResultEntryExitDto>> GetAllEntryExitAsync()
        {
            var entryExits = await _repository.GetAllAsync();
            var result = new List<ResultEntryExitDto>();

            foreach (var entryExit in entryExits)
            {
                result.Add(new ResultEntryExitDto
                {
                    EntryExitId = entryExit.EntryExitId,
                    ReservationId = entryExit.ReservationId,
                    EntryTime = entryExit.EntryTime,
                    ExitTime = entryExit.ExitTime,
                    Status = entryExit.Status,
                    CreationDate = entryExit.CreationDate,
                    UpdateDate = entryExit.UpdateDate,
                });
            }

            return result;
        }

        public async Task<GetByIdEntryExitDto> GetEntryExitByIdAsync(int model)
        {
            var entryExit = await _repository.GetByIdAsync(model);
            return new GetByIdEntryExitDto
            {
                EntryExitId = entryExit.EntryExitId,
                ReservationId = entryExit.ReservationId,
                EntryTime = entryExit.EntryTime,
                ExitTime = entryExit.ExitTime,
                Status = entryExit.Status,
                CreationDate = entryExit.CreationDate,
                UpdateDate = entryExit.UpdateDate,
            };
        }

        public async Task UpdateEntryExitAsync(UpdateEntryExitDto model)
        {
            var entryExit = await _repository.GetByIdAsync(model.EntryExitId);

            entryExit.ReservationId = model.ReservationId;
            entryExit.EntryTime = model.EntryTime;
            entryExit.ExitTime = model.ExitTime;
            entryExit.Status = model.Status;
            entryExit.CreationDate = model.CreationDate;
            entryExit.UpdateDate = model.UpdateDate;

            await _repository.UpdateAsync(entryExit);
        }
    }
}