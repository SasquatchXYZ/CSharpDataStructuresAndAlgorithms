using TreeDatastructures.Binary;

namespace SimpleQuiz;

public class Quiz
{
    public static BinaryTree<string> GetTree()
    {
        var tree = new BinaryTree<string>();
        tree.Root = new BinaryTreeNode<string>
        {
            Data = "Do you have an experience in app development?",
            Children =
            [
                new BinaryTreeNode<string>
                {
                    Data = "Have you worked as a developer for 5+ years?",
                    Children =
                    [
                        new BinaryTreeNode<string>
                        {
                            Data = "Apply as a senior developer"
                        },
                        new BinaryTreeNode<string>
                        {
                            Data = "Apply as a middle developer"
                        },
                    ]
                },
                new BinaryTreeNode<string>
                {
                    Data = "Have you completed a university degree?",
                    Children =
                    [
                        new BinaryTreeNode<string>
                        {
                            Data = "Apply as a junior developer"
                        },
                        new BinaryTreeNode<string>
                        {
                            Data = "Will you find some time during the semester?",
                            Children =
                            [
                                new BinaryTreeNode<string>
                                {
                                    Data = "Apply for long-time internship"
                                },
                                new BinaryTreeNode<string>
                                {
                                    Data = "Apply for summer internship"
                                },
                            ]
                        },
                    ]
                }
            ]
        };

        tree.Count = 9;
        return tree;
    }
}
