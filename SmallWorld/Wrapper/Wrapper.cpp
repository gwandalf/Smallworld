// Il s'agit du fichier DLL principal.

#include "stdafx.h"

#include "Wrapper.h"
#include "C:\Users\Gwendal\Documents\Visual Studio 2012\Projects\SmallWorld\LibC++\Example.h"
#include "C:\Users\Gwendal\Documents\Visual Studio 2012\Projects\SmallWorld\LibC++\Example.cpp"

Wrapper::ExampleWrapper::ExampleWrapper(void)
{
	myExample = new Example();
}

Wrapper::ExampleWrapper::ExampleWrapper(int b)
{
	myExample = new Example(b);
}

Wrapper::ExampleWrapper::~ExampleWrapper(void)
{
}

int Wrapper::ExampleWrapper::wrapperGetA() {
	return myExample->getA();
}