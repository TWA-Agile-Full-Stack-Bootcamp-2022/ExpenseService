using Expense.Service;
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
            Project project = new Project(ProjectType.INTERNAL, "Internal Project");

            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);

            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project A");

            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);

            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Project B");

            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);

            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            Project project = new Project(ProjectType.EXTERNAL, "Other Project");

            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);

            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project project = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, "Other Project");

            // when
            // NOTE: The Action passed to Assert.Throws needs to be a delegate that matches the Action signature. Specifically: public delegate void Action(); So the Action needs to be a method that takes no parameters and returns void.
            void Action() => ExpenseService.GetExpenseCodeByProjectTypeAndName(project);

            // then
            var exception = Assert.Throws<UnexpectedProjectTypeException>(Action);
            Assert.Equal("You enter invalid project type", exception.Message);
        }
    }
}
