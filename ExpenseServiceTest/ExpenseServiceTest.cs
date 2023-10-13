using System;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project internalProject = new Project(ProjectType.INTERNAL, "A Internal Project");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(internalProject);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project projectA = new Project(ProjectType.EXTERNAL, "Project A");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectA);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project projectB = new Project(ProjectType.EXTERNAL, "Project B");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectB);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            Project projectOther = new Project(ProjectType.EXTERNAL, "Project Other");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectOther);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project projectUnexpected = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "Project Unexpected");
            // when
            Action action = () => ExpenseService.GetExpenseCodeByProjectTypeAndName(projectUnexpected);
            // then
            UnexpectedProjectTypeException exception = Assert.Throws<UnexpectedProjectTypeException>(action);
            Assert.Equal("You enter invalid project type", exception.Message);
        }
    }
}