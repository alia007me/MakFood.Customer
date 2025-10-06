using MakFood.Customer.Domain.Models.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.UpdateUserInfo
{
    public record UpdateUserInfoCommand(
        Guid Id,string? FirstName, string? LastName,Guid? AddresId,string? AddresTitle, string? StreetAddres, uint HouseNumber, string? UnitNo, string? PostalCode
        ):IRequest<string>;
}
