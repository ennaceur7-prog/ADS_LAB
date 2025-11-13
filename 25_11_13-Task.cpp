#include <iostream>
#include <queue>
using namespace std;

struct Node {
    int val;
    Node* left;
    Node* right;
    Node(int v) : val(v), left(nullptr), right(nullptr) {}
};

class BST {
public:
    BST() : root(nullptr) {}
    ~BST() { deleteTree(root); }

    // Public wrappers
    void insert(int v) { root = insertRec(root, v); }
    bool search(int v) const { return searchRec(root, v); }
    void remove(int v) { root = deleteRec(root, v); }

    // Update value
    // returns true if update performed
    bool update(int oldVal, int newVal) {
        if (!search(oldVal)) return false;         // nothing to update
        if (newVal != oldVal && search(newVal)) return false;
        root = deleteRec(root, oldVal);
        root = insertRec(root, newVal);
        return true;
    }

    // Traversals
    void inorder()  const { inorderRec(root); cout << '\n'; }
    void preorder() const { preorderRec(root); cout << '\n'; }
    void postorder() const { postorderRec(root); cout << '\n'; }
    void levelOrder() const { levelOrderRec(root); cout << '\n'; }

private:
    Node* root;

    // Recursive insert
    Node* insertRec(Node* node, int v) {
        if (!node) return new Node(v);
        if (v < node->val)
            node->left = insertRec(node->left, v);
        else if (v > node->val)
            node->right = insertRec(node->right, v);
        return node;
    }

    bool searchRec(Node* node, int v) const {
        if (!node) return false;
        if (v == node->val) return true;
        if (v < node->val) return searchRec(node->left, v);
        return searchRec(node->right, v);
    }

    // Find minimum node in subtree
    Node* minValueNode(Node* node) {
        Node* current = node;
        while (current && current->left) current = current->left;
        return current;
    }

    // Recursive delete
    Node* deleteRec(Node* node, int v) {
        if (!node) return node;
        if (v < node->val) {
            node->left = deleteRec(node->left, v);
        } else if (v > node->val) {
            node->right = deleteRec(node->right, v);
        } else {
            
            // Case 1: no child or one child
            if (!node->left) {
                Node* temp = node->right;
                delete node;
                return temp;
            } else if (!node->right) {
                Node* temp = node->left;
                delete node;
                return temp;
            }
            // Case 2: two children 
            Node* temp = minValueNode(node->right);
            node->val = temp->val;
            node->right = deleteRec(node->right, temp->val);
        }
        return node;
    }

    // Traversal helpers
    void inorderRec(Node* node) const {
        if (!node) return;
        inorderRec(node->left);
        cout << node->val << " ";
        inorderRec(node->right);
    }
    void preorderRec(Node* node) const {
        if (!node) return;
        cout << node->val << " ";
        preorderRec(node->left);
        preorderRec(node->right);
    }
    void postorderRec(Node* node) const {
        if (!node) return;
        postorderRec(node->left);
        postorderRec(node->right);
        cout << node->val << " ";
    }
    void levelOrderRec(Node* node) const {
        if (!node) return;
        queue<Node*> q;
        q.push(node);
        while (!q.empty()) {
            Node* cur = q.front(); q.pop();
            cout << cur->val << " ";
            if (cur->left) q.push(cur->left);
            if (cur->right) q.push(cur->right);
        }
    }

    // Delete tree
    void deleteTree(Node* node) {
        if (!node) return;
        deleteTree(node->left);
        deleteTree(node->right);
        delete node;
    }
}; 

// Demo
int main() {
    BST tree;

    // Insert elements
    tree.insert(10);
    tree.insert(5);
    tree.insert(15);
    tree.insert(3);
    tree.insert(7);
    tree.insert(12);
    tree.insert(18);

    cout << "Inorder  (sorted): ";
    tree.inorder();    // 3 5 7 10 12 15 18

    cout << "Preorder: ";
    tree.preorder();

    cout << "Postorder: ";
    tree.postorder();

    cout << "Level-order: ";
    tree.levelOrder();

    // Search
    cout << "Search 7: " << (tree.search(7) ? "found\n" : "not found\n");
    cout << "Search 4: " << (tree.search(4) ? "found\n" : "not found\n");

    // Update value (7 -> 8)
    cout << "Update 7 -> 8: " << (tree.update(7, 8) ? "ok\n" : "failed\n");
    cout << "Inorder after update: ";
    tree.inorder();    // 3 5 8 10 12 15 18

    // Delete a leaf (3)
    tree.remove(3);    // leaf
    cout << "After deleting 3: ";
    tree.inorder();

    tree.remove(15);
    cout << "After deleting 15: ";
    tree.inorder();

    return 0;
}
