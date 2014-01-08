// Il s'agit du fichier DLL principal.

#include "stdafx.h"
#include "Wrapper.h"

using namespace Wrapper;

CarteWrapper::CarteWrapper(void) { myCarte = Carte_New_default(); }
CarteWrapper::CarteWrapper(int dim, int army_length) { myCarte = Carte_New(dim, army_length); }
CarteWrapper::~CarteWrapper(void) { Carte_Delete(myCarte); }

void CarteWrapper::generateCases(int nbTypes) { myCarte->generateCases(nbTypes); }
void CarteWrapper::placeUnites(int begin, int end, int lig, int col) { myCarte->placeUnites(begin, end, lig, col); }
int CarteWrapper::getDim() {return myCarte->getDim();}
int CarteWrapper::getCases(int x, int y) {return myCarte->getCases(x, y);}
System::Collections::Generic::List<int>^ CarteWrapper::getMoves(int x, int y) {
	System::Collections::Generic::List<int>^ lMoves = gcnew System::Collections::Generic::List<int>();
	int * moves = myCarte->getMoves(x, y);
	//We skip the weight for now
	int j = 0;
	int i = 0;
			while (j != 3){
				if (moves[i] != -1){
					lMoves->Add(moves[i]);
					j++;
				}
				i++;
			}
	

	delete [] moves;
	return lMoves;
}
CarteWrapper::!CarteWrapper() { Carte_Delete(myCarte); }