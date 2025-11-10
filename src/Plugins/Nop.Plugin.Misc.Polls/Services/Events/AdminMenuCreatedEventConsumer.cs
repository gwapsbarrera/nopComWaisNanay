using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.Polls.Services.Events;

/// <summary>
/// Represents the plugin event consumer
/// </summary>
public class AdminMenuCreatedEventConsumer : IConsumer<AdminMenuCreatedEvent>
{
    #region Fields

    private readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor

    public AdminMenuCreatedEventConsumer(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Handle admin menu created event
    /// </summary>
    /// <param name="eventMessage">Event message</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task HandleEventAsync(AdminMenuCreatedEvent eventMessage)
    {
        eventMessage.RootMenuItem.InsertAfter("Blog comments", new AdminMenuItem
        {
            SystemName = "Polls",
            Title = await _localizationService.GetResourceAsync("Plugins.Misc.Polls"),
            PermissionNames = new List<string> { PollsDefaults.Permissions.POLLS_VIEW },
            Url = eventMessage.GetMenuItemUrl("PollAdmin", "List"),
            IconClass = "far fa-dot-circle"
        });
    }

    #endregion
}