using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    /// <summary>
    /// Manages a single customer.
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            // Try 3

            if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", "goalSteps");
            if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps count must be entered", "actualSteps");
 
            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric");

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric", "actualSteps");

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }

        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater than 0", "goalSteps");
            return Math.Round(actualStepCount / goalStepCount * 100,2);
        }

        /// <summary>
        /// Validates the customer email address.
        /// </summary>
        /// <returns></returns>
        public OperationResult ValidateEmail()
        {
            var op = new OperationResult();

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                op.Success = false;
                op.AddMessage("Email address is null");
            }

            if (op.Success)
            {
                var isValidFormat = true;
                // Code here that validates the format of the email
                // using Regular Expressions.
                if (!isValidFormat)
                {
                    op.Success = false;
                    op.AddMessage("Email address is not in a correct format");
                }
            }

            if (op.Success)
            {
                var isRealDomain = true;
                // Code here that confirms whether domain exists.
                if (!isRealDomain)
                {
                    op.Success = false;
                    op.AddMessage("Email address does not include a valid domain");
                }
            }
            return op;
        }
    }
}

