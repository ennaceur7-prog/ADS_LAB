#include <iostream>
#include <string>

using namespace std;

struct Node {
    string data;
    Node* next;
    Node* prev;
    Node(const string& d) : data(d), next(nullptr), prev(nullptr) {}
};

class DoublyLinkedList {
private:
    Node* head;
    Node* tail;

public:
    DoublyLinkedList() : head(nullptr), tail(nullptr) {}
    
    // destructor: free all nodes
    ~DoublyLinkedList() {
        Node* cur = head;
        while (cur) {
            Node* nxt = cur->next;
            delete cur;
            cur = nxt;
        }
    }

    // append to end
    void append(const string& value) {
        Node* node = new Node(value);
        if (!head) {
            head = tail = node;
        } else {
            tail->next = node;
            node->prev = tail;
            tail = node;
        }
    }

    // print from head to tail
    void printForward() const {
        Node* cur = head;
        while (cur) {
            cout << cur->data;
            if (cur->next) cout << " <-> ";
            cur = cur->next;
        }
        cout << endl;
    }

    // print from tail to head
    void printBackward() const {
        Node* cur = tail;
        while (cur) {
            cout << cur->data;
            if (cur->prev) cout << " <-> ";
            cur = cur->prev;
        }
        cout << endl;
    }

    // optional: remove first occurrence of value (keeps it simple)
    bool remove(const string& value) {
        Node* cur = head;
        while (cur) {
            if (cur->data == value) {
                if (cur->prev) cur->prev->next = cur->next;
                else head = cur->next; // removing head

                if (cur->next) cur->next->prev = cur->prev;
                else tail = cur->prev; // removing tail

                delete cur;
                return true;
            }
            cur = cur->next;
        }
        return false;
    }
};

int main() {
    DoublyLinkedList list;
    list.append("test1");
    list.append("test2");
    list.append("test3");

    cout << "Forward:  ";
    list.printForward();   // test1 <-> test2 <-> test3

    cout << "Backward: ";
    list.printBackward();  // test3 <-> test2 <-> test1

    cout << "\nRemoving 'test2'...\n";
    if (list.remove("test2")) {
        cout << "Forward after remove: ";
        list.printForward();  // test1 <-> test3
        cout << "Backward after remove: ";
        list.printBackward(); // test3 <-> test1
    } else {
        cout << "Value not found\n";
    }

    return 0;
}
