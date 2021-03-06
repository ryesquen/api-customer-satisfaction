﻿using api_customer_satisfaction.Models;
using api_customer_satisfaction.ServiceSoap.DataContract;
using System.Collections.Generic;
using System.Linq;

namespace api_customer_satisfaction.ServiceSoap.ServiceContract
{
    public class EvaluationService : IEvaluationService
    {
        readonly Context _context;
        public EvaluationService(Context context)
        {
            _context = context;
        }
        public IEnumerable<EvaluationModel> GetAllSoap()
        {
            var evaluations = _context.Evaluations.ToList();
            return ListEvaluationToListEvaluationModel(evaluations);
        }
        private IEnumerable<EvaluationModel> ListEvaluationToListEvaluationModel(List<Evaluation> evaluations)
        {
            List<EvaluationModel> lstEvaluationModel = new List<EvaluationModel>();
            EvaluationModel evaluationModel;
            foreach (Evaluation evaluation in evaluations)
            {
                evaluationModel = new EvaluationModel
                {
                    id = evaluation.Id,
                    email = evaluation.Email,
                    firstName = evaluation.FirstName,
                    lastName = evaluation.LastName,
                    qualification = evaluation.Qualification,
                    evaluationDate = evaluation.EvaluationDate
                };
                lstEvaluationModel.Add(evaluationModel);
            }
            return lstEvaluationModel;
        }
        public EvaluationModel GetByIdSoap(int id)
        {
            var evaluation = _context.Evaluations.FirstOrDefault(e => e.Id == id);
            return EvaluationToEvaluationModel(evaluation);
        }
        private EvaluationModel EvaluationToEvaluationModel(Evaluation evaluation)
        {
            return new EvaluationModel
            {
                id = evaluation.Id,
                email = evaluation.Email,
                firstName = evaluation.FirstName,
                lastName = evaluation.LastName,
                qualification = evaluation.Qualification,
                evaluationDate = evaluation.EvaluationDate
            };
        }
    }
}