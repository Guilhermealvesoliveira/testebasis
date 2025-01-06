using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures
{
    public class ListSubjectUseCaseFixture
    {
        private readonly Fixture _fixture;
        public ListSubjectUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public ListSubjectInput CreateRequest()
        {
            return _fixture.Create<ListSubjectInput>();
        }
        public ListSubjectOutput CreateResponse(bool withSubjects = true)
        {
            var output = _fixture.Create<ListSubjectOutput>();

            if (withSubjects)
            {
                output.Data = new List<ListSubjectOutputData>
                {
                    _fixture.Create<ListSubjectOutputData>(),
                     _fixture.Create<ListSubjectOutputData>(),
                };
            }
            else
            {
                output.Data = new List<ListSubjectOutputData>();
            }

            return output;
        }
    }
}
