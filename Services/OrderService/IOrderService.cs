using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetMenuItemDto>>> GetAllEntries();
        Task<ServiceResponse<GetMenuItemDto>> GetEntryById(int id);
        Task<ServiceResponse<List<GetMenuItemDto>>> AddEntry(AddEntryRequestDto newCharacter);
        Task<ServiceResponse<GetMenuItemDto>> UpdateEntry(UpdateEntryDto updatedEntry);
        Task<ServiceResponse<List<GetMenuItemDto>>> DeleteEntry(int id);
    }
}