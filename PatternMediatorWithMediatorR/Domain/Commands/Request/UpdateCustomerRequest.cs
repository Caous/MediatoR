﻿using MediatR;
using PatternMediatorWithMediatorR.Domain.Commands.Response;

namespace PatternMediatorWithMediatorR.Domain.Commands.Request;

public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}