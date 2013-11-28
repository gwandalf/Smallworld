// Wrapper.h

#pragma once
#include "..\LibC++\Carte.h"
#include "..\LibC++\Carte.cpp"

using namespace System;

namespace Wrapper {

	public ref class CarteWrapper
	{

	public:
		CarteWrapper(void);
		CarteWrapper(int dim, vector<int> army1, vector<int> army2);
		~CarteWrapper(void);

		void generateCases(int nbTypes);
		void placeUnites(vector<int> unites, int lig, int col);

	private:
		Carte *myCarte;
	};
}
