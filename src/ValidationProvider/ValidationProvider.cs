﻿namespace Validations
{
    using System;

    using Contracts;

    public static class ValidationProvider
    {
        public class UserInputValidator : IUserInputValidator
        {
            private const char COMMA = ',';
            private const char DOT = '.';
            private const int VALID_INPUT_LENGTH = 3;
            private const int MAX_ROW_INPUT_VALUE = 4;

            private static readonly UserInputValidator instance = new UserInputValidator();

            private UserInputValidator()
            {

            }

            public static UserInputValidator Instance
            {
                get
                {
                    return UserInputValidator.instance;
                }
            }

            public bool IsValidUserMove(string userInput)
            {
                bool hasCorrectLength = userInput.Length == VALID_INPUT_LENGTH;
                if(!hasCorrectLength)
                {
                    return false;
                }
                bool firstCharIsDigit = char.IsDigit(userInput[2]);
                bool secondCharIsValid = char.IsWhiteSpace(userInput[1]) || userInput[1] == DOT || userInput[1] == COMMA;
                bool thirdCharIsDigit = char.IsDigit(userInput[2]);

                return firstCharIsDigit && secondCharIsValid && thirdCharIsDigit && this.IsValidRowMove(userInput[0]);
            }

            private bool IsValidRowMove(char notParsedRow)
            {
                bool isValidRow = (notParsedRow - 48) <= MAX_ROW_INPUT_VALUE;
                return isValidRow;
            }
        }

        public static IUserInputValidator InputValidator
        {
            get
            {
                return UserInputValidator.Instance;
            }
        }

        // this is the the template for a validator

        //public class ValidatorTemplate
        //{
        //    private static readonly ValidatorTemplate instance = new ValidatorTemplate();

        //    private ValidatorTemplate()
        //    {

        //    }

        //    public static ValidatorTemplate Instance
        //    {
        //        get
        //        {
        //            return instance;
        //        }
        //    }

        //    public bool IsValid()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public static ValidatorTemplate Validator
        //{
        //    get
        //    {
        //        return ValidatorTemplate.Instance;
        //    }
        //}

    }
}