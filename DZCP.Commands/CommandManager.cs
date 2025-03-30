using System;
using System.Collections.Generic;
using System.Reflection;
using DZCP.API.Models;
using DZCP.Logging;

namespace DZCP.Commands
{
    public static class CommandManager
    {
        private static readonly Dictionary<string, CommandInfo> _commands = new();

        public static void RegisterCommands(object commandHandler)
        {
            Type type = commandHandler.GetType();
            foreach (MethodInfo method in type.GetMethods())
            {
                CommandAttribute attribute = method.GetCustomAttribute<CommandAttribute>();
                if (attribute != null)
                {
                    _commands[attribute.Name.ToLower()] = new CommandInfo
                    {
                        Handler = commandHandler,
                        Method = method,
                        Description = attribute.Description,
                        Permission = attribute.Permission
                    };
                }
            }
        }

        public static bool Execute(Player player, string command, string[] args)
        {
            if (_commands.TryGetValue(command.ToLower(), out CommandInfo cmdInfo))
            {
                if (!string.IsNullOrEmpty(cmdInfo.Permission) &&
                    !player.HasPermission(cmdInfo.Permission))
                {
                    player.SendMessage("You don't have permission to use this command!");
                    return false;
                }

                try
                {
                    cmdInfo.Method.Invoke(cmdInfo.Handler, new object[] { player, args });
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Command execution error: {ex}");
                    return false;
                }
            }
            return false;
        }
    }

    public class CommandInfo
    {
        public object Handler { get; set; }
        public MethodInfo Method { get; set; }
        public string Description { get; set; }
        public string Permission { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public string Permission { get; }

        public CommandAttribute(string name, string description = "", string permission = "")
        {
            Name = name;
            Description = description;
            Permission = permission;
        }
    }
}
