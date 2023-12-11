﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.Associados
{
    public class IndexModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;
        private readonly Teste.Servico.AssociadoServico _servico;

        public IndexModel(Teste.Data.AplicationDbContext context, Teste.Servico.AssociadoServico servico)
        {
            _context = context;
            _servico = servico; 
        }

        public IList<AssociadosEntity> AssociadosEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AssociadosEntity = await _context.AssociadosEntity.ToListAsync();
            AssociadosEntity = await _servico.GetAssociados(null, null);
        }
    }
}
