using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerHub.Application.DTOs
{
    public record CustomerResponseDto(
      Guid Id,
      string Name,
      string Email
  );
}
