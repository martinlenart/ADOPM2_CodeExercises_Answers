using System;

namespace ErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProcessUserInput();
            }
            catch
            {
                Console.WriteLine("Plc contact our service center, you have a virus in yourc computer");
            }
        }
        private static void ProcessUserInput()
        {
            bool quit = false;
            Console.WriteLine("Don't Press Button 5 or 7!");
            do
            {
                Console.WriteLine("Which button do you want to press?");
                string sButtonToPress = Console.ReadLine();

                if (sButtonToPress == "q")
                {
                    quit = true;
                }
                else
                {
                    int buttonToPress;
                    if (int.TryParse(sButtonToPress, out buttonToPress))
                    {
                        try
                        {
                            PressTheButton(buttonToPress);
                            Console.WriteLine("Indeed the button was pressed successfully");
                        }
                        catch (InsufficientMemoryException ex)
                        {
                            Console.WriteLine($"{ex.Message} - Why cant you listen!!");
                            throw;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message} - But it is alright my friend!");
                        }
                        finally
                        {
                            Console.WriteLine("Code here will always be executed!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, try again");
                    }
                }
            } while (!quit);
        }
        static void PressTheButton(int buttonNr)
        {
            if (buttonNr == 5)
                throw new Exception("KaBoom!!");

            if (buttonNr == 7)
                throw new InsufficientMemoryException("You hopless guy!");

            Console.WriteLine($"You pressed button {buttonNr}");
        }

        /*
        static void Main(string[] args)
        {
            try
            {
                ProcessUserInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unfortunatly, without memory I cannot continue {ex.Message}");
            }
        }

        private static void ProcessUserInput()
        {
            bool quit = false;
            Console.WriteLine("Don't Press Button 5 or 7!");
            do
            {
                Console.WriteLine("Which button do you want to press?");
                string sButtonToPress = Console.ReadLine();

                if (sButtonToPress == "q")
                {
                    quit = true;
                }
                else
                {
                    int buttonToPress;
                    if (int.TryParse(sButtonToPress, out buttonToPress))
                    {
                        try
                        {
                            PressTheButton(buttonToPress);
                            Console.WriteLine("Indeed the button was pressed successfully");
                        }
                        catch (InsufficientMemoryException ex)
                        {
                            Console.WriteLine("Why did you press button 7! We ran out of memory");
                            throw;
                            //throw new Exception("Sorry, you are hopeless");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"I told you not to press button 5!! {ex.Message}");
                        }
                        finally
                        {
                            Console.WriteLine("Yes, the button was pressed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, try again");
                    }
                }
            } while (!quit);
        }
        */
    }
}
