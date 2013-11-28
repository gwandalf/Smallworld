// Il s'agit du fichier DLL principal.

#include "stdafx.h"
#include "Wrapper.h"

using namespace Wrapper;

CarteWrapper::CarteWrapper(void)
{
	myCarte = Carte_New();
}

CarteWrapper::CarteWrapper(int dim, vector<int> army1, vector<int> army2) {
	myCarte = Carte_New(dim, army1, army2);
}

CarteWrapper::~CarteWrapper(void) {
	Carte_Delete(myCarte);
}

void CarteWrapper::generateCases(int nbTypes) {
	myCarte->generateCases(nbTypes);
}

void CarteWrapper::placeUnites(vector<int> unites, int lig, int col) {
	myCarte->placeUnites(unites, lig, col);
}