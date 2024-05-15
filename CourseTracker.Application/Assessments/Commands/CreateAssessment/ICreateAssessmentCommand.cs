﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTracker.Application.Assessments.Commands.CreateAssessment
{
	
	public interface ICreateAssessmentCommand
	{

		Guid Execute(CreateAssessmentModel model);

	}

}
