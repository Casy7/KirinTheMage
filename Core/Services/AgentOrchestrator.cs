using KiriTheMage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiriTheMage.Core.Services
{

    public class AgentOrchestrator
    {
        private readonly IMemoryService _memory;
        private readonly IAiBrainService _brain;
        private readonly ISystemInteractor _system;
        private readonly IAvatarViewModel _avatar;

        // injecting all dependencies through the constructor
        public AgentOrchestrator(
            IMemoryService memory,
            IAiBrainService brain,
            ISystemInteractor system,
            IAvatarViewModel avatar)
        {
            _memory = memory;
            _brain = brain;
            _system = system;
            _avatar = avatar;
        }

        public void ProcessUserCommand(string spokenText)
        {
            // switch avatar to thinking state
            _avatar.PlayAnimation("thinking");

            string context = _memory.GetRecentContext(5);
            string profile = _memory.GetUserProfile();

            string fullPrompt = $"profile: {profile}\ncontext: {context}\ncommand: {spokenText}";

            // get decision from ai
            string aiResponse = _brain.GenerateResponse("you are a desktop cat mage.", fullPrompt);

            _memory.SaveInteraction(spokenText, aiResponse);

            // parsing ai z to execute actions or just talk
            ExecuteActionBasedOnAi(aiResponse);
        }

        private void ExecuteActionBasedOnAi(string response)
        {
            // simple check just for structure demonstration
            if (response.Contains("click"))
            {
                _avatar.PlayAnimation("teleport_out");
                _avatar.MoveTo(500, 500);
                _avatar.PlayAnimation("teleport_in");
                _system.TeleportCursorAndClick(500, 500);
            }
            else
            {
                _avatar.PlayAnimation("idle_happy");
            }
        }
    }
}
