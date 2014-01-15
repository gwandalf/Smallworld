// Il s'agit du fichier DLL principal.

#include "stdafx.h"
#include "Wrapper.h"

using namespace Wrapper;

CarteWrapper::CarteWrapper(void) { myCarte = Carte_New_default(); }
CarteWrapper::CarteWrapper(int dim, int army_length) { myCarte = Carte_New(dim, army_length); }
CarteWrapper::~CarteWrapper(void) { Carte_Delete(myCarte); }

void CarteWrapper::generateCases(int nbTypes) { myCarte->generateCases(nbTypes); }
void CarteWrapper::placeUnites(int begin, int end, int lig) { myCarte->placeUnites(begin, end, lig); }
int CarteWrapper::getDim() {return myCarte->getDim();}
int CarteWrapper::getCases(int x, int y) {return myCarte->getCases(x, y);}
int CarteWrapper::getPlace(int num, int coord) {return myCarte->getPlace(num, coord);}

CarteWrapper::!CarteWrapper() { Carte_Delete(myCarte); }