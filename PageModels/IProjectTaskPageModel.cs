using CommunityToolkit.Mvvm.Input;
using ProjectDungbeetle.Models;

namespace ProjectDungbeetle.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}