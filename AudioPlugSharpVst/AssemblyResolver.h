#pragma once

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::Loader;

public ref class AssemblyResolver
{
public:
	static void RegisterResolver();
	static System::Reflection::Assembly^ ResolveAssembly(AssemblyLoadContext^ assemblyLoadContext, AssemblyName^ assemblyName);
	static System::Reflection::Assembly^ LoadAssembly(System::String^ assemblyName);
	static System::Object^ GetObjectByInterface(System::Reflection::Assembly^ assembly, System::Type^ interfaceType);
};

