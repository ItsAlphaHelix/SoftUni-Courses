﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerCellOfficerByIdExportModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public List<OfficerExportModel> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
