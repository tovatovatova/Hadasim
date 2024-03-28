#include <iostream>
using namespace std;
#include <cmath>

// Function to check whether to calculate area or perimeter of a rectangular tower
void check_rec(int height, int width) {
	if (height == width || abs(height - width) > 5)  //Area 
	{
		double area = height * width;
		cout << "Rectangular tower area: " << area << endl;
	}
	else
	{
		double perimeter = (2 * height) + (2 * width);  //Parimeter
		cout << "Rectangular tower perimeter: " << perimeter << endl;
	}
}
// Function to print the triangle tower pattern
void print_triangle(int height, int width) {
	int space, stars = 1;
	int groups = 1+width/2; //Count the number of times that number of stars in the current line bigger than the previous line.
	int rest = (height - 2) % (groups-2);//The rest of division for add to the first group 
	/*Create array that contain number of group member for each group 
	(group is the lines with the same width first group is width=1 and the last is width="width")
	Initialize the array with:
	1-for the first group that have only one line
	rest- for the second group that take the rest of division
	The other elements initialize with the value-0
	*/
	int* numOfSame = new int[groups+1] {1,rest}; //Create array that contain number of group member for each group (group is the lines with the same width first group is width=1 and the last is width="width")
	numOfSame[groups - 1] = 1;//The last group is the line with numOfStars=width
	for (int i = 1; i < groups - 1; i++)
	{
		numOfSame[i] = numOfSame[i] + ((height - 2) / (groups - 2)); // Fill the number of lines in each group
	}

	// Loop to print the triangle tower pattern
	for (int k = 0; k < groups; k++)
	{
		for (int i = 0; i < numOfSame[k]; i++)
		{
			space = (width - stars) / 2;
			// Print spaces
			for (int j = 0; j < space; j++)
			{
				cout << " ";
			}
			// Print stars
			for (int j = 0; j < stars; j++)
			{
				cout << "*";
			}
			// Print spaces
			for (int j = 0; j < space; j++)
			{
				cout << " ";
			}
			cout << endl;
		}
		stars += 2; // Increase the number of stars for the next group
	}
	delete[] numOfSame;  // Free dynamic memory
}

// Function to check whether to calculate perimeter or print triangle tower
void check_tr(int choice, int height, int width) {
	if (choice == 1)
	{
		double tr_side = sqrt(pow((width / 2), 2) + pow(height, 2));
		cout << "Triangular tower perimeter: " << 2 * tr_side + width << endl;
	}
	else {
		if ((int(width) % 2 == 0) || (width > (2 * height)))
			cout << "We can't print this triangle" << endl;
		else {
			print_triangle(height, width);
		}


	}
}
// Function to receive user choice
int receiveChoice() {
	int choice;
	cout << "choose one of the three following options:\n";
	cout << "1 - For a rectangular tower\n";
	cout << "2 - For a triangular tower\n";
	cout << "3 - For EXIT\n";
	cout << "Your choice: ", cin >> choice;
	// Validate user input
	while (choice < 1 || choice>3)
	{
		cout << "Your choice is not exist, try again:\n";
		cout << "Your choice: ", cin >> choice;
	}
	return choice;
}
int main()
{
	int choice, triangle_choice, height, width;
	choice = receiveChoice();
	while (choice != 3)
	{
		cout << "Please enter the height and the width of the tower:\nHight:", cin >> height, cout << "Width:", cin >> width;
		if (choice == 1) //Rectangular tower
			check_rec(height, width); // Check and display rectangular tower area or perimeter
		if (choice == 2)//Triangular tower
		{
			cout << "\nEnter 1 to calculate the perimeter of the triangle tower and 2 to print the triangle tower:\n";
			cout << "Your choice: ", cin >> triangle_choice;
			// Validate triangle choice
			while (triangle_choice != 1 && triangle_choice != 2)  
			{
				cout << "Your choice is not exist, try again:\n";
				cout << "Your choice: ", cin >> triangle_choice;
			}
		 // Check and calculate perimeter or print the triangle tower

			check_tr(triangle_choice, height, width);
			choice = receiveChoice();
		}

	}//End of while 

	cout << "Bye Bye!\n";  //When the user choice to EXIT (3)

}

