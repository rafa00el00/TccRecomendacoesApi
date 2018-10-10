using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.FeedbackApi.Models.DTO;

namespace TCCApi.FeedbackApi.Dados
{




    public interface IFeedbackDados : IGenericDados<FeedbackDTO>
    {
        
    }

    public class FeedbackDados : GenericDados<FeedbackDTO> , IFeedbackDados
    {
        private readonly DbContext _context;

        public FeedbackDados(DbContext context):base(context)
        {
            this._context = context;
        }

        

        
    }

   

   
}
