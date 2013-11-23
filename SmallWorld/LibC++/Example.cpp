#pragma once
#include "Example.h"


Example::Example(void)
{
}

Example::Example(int b)
{
	a = b;
}

Example::~Example(void)
{
}

int Example::getA() {
	return a;
}
