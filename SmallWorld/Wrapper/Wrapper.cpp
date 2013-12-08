// Il s'agit du fichier DLL principal.

#include "stdafx.h"
#include "Wrapper.h"

using namespace Wrapper;

CarteWrapper::CarteWrapper(void)
{
	myCarte = new Carte();
}

CarteWrapper::CarteWrapper(int dim, int army_length) {
	myCarte = new Carte(dim, army_length);
}

CarteWrapper::~CarteWrapper(void) {
	delete myCarte;
}

void CarteWrapper::generateCases(int nbTypes) {
	myCarte->generateCases(nbTypes);
}

void CarteWrapper::placeUnites(int begin, int end, int lig, int col) {
	myCarte->placeUnites(begin, end, lig, col);
}