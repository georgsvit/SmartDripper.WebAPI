using SmartDripper.WebAPI.Data;
using SmartDripper.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services.Domain
{
    public class MedicamentLogNoteService
    {
        private readonly ApplicationContext applicationContext;

        public MedicamentLogNoteService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task AddNote(Guid id)
        {
            MedicamentLogNote note = new MedicamentLogNote(id);

            await applicationContext.MedicamentLogNotes.AddAsync(note);
            await applicationContext.SaveChangesAsync();
        }
    }
}
