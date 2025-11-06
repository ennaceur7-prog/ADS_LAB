#include <iostream>
#include <string>
using namespace std;

struct Node {
    string data;
    Node* next_ptr;
    Node(const string& d = "", Node* next = nullptr) : data(d), next_ptr(next) {}
};

int main() {
    Node node3("test3");
    Node node2("test2", &node3);
    Node node1("test1", &node2);

    Node* current = &node1;
    while (current != nullptr) {
        cout << current->data << " ";
        current = current->next_ptr;
    }
    cout << endl;
    return 0;
}
