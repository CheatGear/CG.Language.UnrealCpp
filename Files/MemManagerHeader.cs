﻿using System;
using System.IO;
using System.Threading.Tasks;
using CG.SDK.Dotnet.Helper;
using CG.SDK.Dotnet.Plugin.Output;

namespace CG.Output.Files;

public class MemManagerHeader : IncludeFile<UnrealCpp>
{
    public MemManagerHeader(UnrealCpp lang) : base(lang)
    {
    }

    public override string FileName { get; } = "MemoryManager.h";
    public override bool IncludeInMainSdkFile { get; } = false;

    public override ValueTask<string> ProcessAsync(OutputPurpose processPurpose)
    {
        if (Lang.SdkFile is null)
        {
            throw new InvalidOperationException("Invalid output target.");
        }

        // Read File
        return CGUtils.ReadEmbeddedFileAsync(Path.Combine("External", FileName), GetType().Assembly);
    }
}
