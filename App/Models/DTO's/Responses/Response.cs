using System;

namespace Models
{
    public class Response
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "Failed";

        public Response() { }
        public Response(TripRateContext context)
        {
            try
            {
                var changedRecords = context.SaveChanges();

                if (changedRecords > 0)
                {
                    this.Success = true;
                    this.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                this.Success = false;
                this.Message = string.Format("Error: {0}", ex.Message);
            }
        }
    }
}
