namespace OngsPet.Communication.Responses
{
    public class ResponseErrorDTO
    {
        public IList<string> Errors { get; set; }

        public ResponseErrorDTO(IList<string> errors)
        {
            Errors = errors;
        }

        public ResponseErrorDTO(string error)
        {
            Errors = new List<string> { error };
        }

    }
}
