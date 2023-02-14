namespace UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;

public record RefreshTokenDto(
    string accessToken,
    string refreshToken);
