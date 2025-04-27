using System;
using System.Collections.Generic;
using DZCP.NewEdition;

public interface IDZCPPlugin
{
    string Name { get; }
    string Prefix { get; }
    Version Version { get; }
    int Priority { get; }
    IDZCPTranslation InternalTranslation { get; }
    void OnEnabled();
    void OnDisabled();
    IDZCPTranslation LoadTranslation(Dictionary<string, object> rawTranslations = null);
}