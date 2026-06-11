using DraasGames.Logging;
using UnityEngine;

namespace DraasGames.Logging.Samples
{
    /// <summary>
    /// Drop this component on any GameObject and enter Play mode, then open
    /// Window > DraasGames > Console to see the messages with levels, senders and tags.
    /// </summary>
    public sealed class DLoggerBasicUsage : MonoBehaviour
    {
        private void Start()
        {
            // Plain messages at each level.
            DLogger.Log("Hello from DLogger!");
            DLogger.LogWarning("Something looks off.");
            DLogger.LogError("Something went wrong.");

            // Pass a sender to prefix messages with [TypeName] and enable sender filtering in DConsole.
            DLogger.Log("Message with a sender.", this);

            // Tags: generate the DLogTags constants class via DraasGames > Logger > Generate Tags,
            // then use DLogTags.UI etc. Dynamic tags work without generation:
            DLogger.Log("Tagged message.", this, DLogTag.Of("Gameplay"), DLogTag.Of("Demo"));

            // Exceptions are captured with their stack trace.
            DLogger.LogException(new System.InvalidOperationException("Demo exception (not a real error)."));
        }
    }
}
