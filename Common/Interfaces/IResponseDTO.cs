namespace MemberProject.Common.Interfaces
{
    public interface IResponseDTO
    {
        #region Public Properties
        bool IsPassed { get; set; }

        string Message { get; set; }

        dynamic Data { get; set; }
        #endregion
    }
}
