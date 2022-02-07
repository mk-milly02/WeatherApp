using Xunit;

public class ApiExtensionsTests
{
    [Fact]
    public void ShouldPass_GetApiKey()
    {
        // Given
        string expectedKey = "1234567890";
        // When
        string actualKey = ApiExtensions.GetApiKey();
        // Then
        Assert.NotEqual(expectedKey, actualKey);
    }
}