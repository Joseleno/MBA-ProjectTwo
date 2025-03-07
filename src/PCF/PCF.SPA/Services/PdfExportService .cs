﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PCF.SPA.Services
{
    public class PdfExportService
    {
        private readonly HttpClient _httpClient;

        public PdfExportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]?> ExportToPdfAsync(List<RelatorioOrcamentoResponse> relatorioOrcamento)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/pdf/generate", relatorioOrcamento);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            return null;
        }
    }
}
