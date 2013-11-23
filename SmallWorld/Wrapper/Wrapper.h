// Wrapper.h

#pragma once
#include "C:\Users\Gwendal\Documents\Visual Studio 2012\Projects\SmallWorld\LibC++\Example.h"
#include "C:\Users\Gwendal\Documents\Visual Studio 2012\Projects\SmallWorld\LibC++\Example.cpp"

using namespace System;

namespace Wrapper {

	public ref class ExampleWrapper
	{
	public:
		ExampleWrapper(void);
		ExampleWrapper(int b);
		~ExampleWrapper(void);

		int wrapperGetA();
	private:
		Example *myExample;
	};
}
