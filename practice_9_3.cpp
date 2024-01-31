#include <bits/stdc++.h>
using namespace std;
const int MAX = 100000;

int st[MAX];
int top = 0;

void init() {
    top = 0;
}

bool isEmpty() {
    return top == 0;
}

bool isFull() {
    return top == MAX;
}

void push(int x) {
    if (isFull()) {
        cout << "error: stack is full." << endl;
        return;
    }
    st[top] = x;
    ++top;
}

int pop() {
    if (isEmpty()) {
        cout << "error: stack is empty." << endl;
        return -1;
    }
    --top;
    return st[top];
}

int main() {
    init();

    string input;
    cout << "input: ";
    cin >> input;
    int left = 0;
    int right = 0;
    
    for(int i=0; i<input.size(); i++)
    {
        if(input[i] == '(') left++;
        else right++;
    }
    if(left != right)
    {
        cout << "error: invalid input." << endl;
        return 0;
    }

    for(int i=0; i<input.size(); i++)
    {
        if(input[i] == '(')
        {
            push(i);
        }
        else
        {
            cout << pop() << " and " << i << endl;
        }
    }
    return 0;
}