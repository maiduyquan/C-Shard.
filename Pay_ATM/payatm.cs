using System.Linq;
class User
{
    public string userName;
    public int cardID;
    int password;
    public int Password
    {
        get { return password; }
        set { password = value; }
    }
    int surplus;
    public int Surplus
    {
        get { return surplus; }
        set { surplus = value; }
    }
    public User(string userName , int cardID, int password, int surplus)
    {
        this.userName = userName;
        this.cardID = cardID;
        this.password = password;
        this.surplus = surplus;
    }
}
class atm
{
    static void displayMenu()
    {
        Console.WriteLine("==============");
        Console.WriteLine("moi chon muc:");
        Console.WriteLine("1.rut tien.");
        Console.WriteLine("2.chuyen khoan.");
        Console.WriteLine("3.hien thi so du.");
        Console.WriteLine("phim khac bat ki de huy thao tac.");
    }
    static void Main(string[] args)
    {
        User user1 = new User("mai quan", 111, 2811, 300);
        User user2 = new User("quan mai", 112, 1128, 300000);
        List<User> Bank = new List<User>();
        Bank.Add(user1);
        Bank.Add(user2);

        int userName, password;
        int count = 0, select, surplus = 300, num;
        int isContinue = 1;

        do
        {
            Console.WriteLine("username:");
            userName = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("password:");
            password = Convert.ToInt32(Console.ReadLine());
            var curentUser = Bank.Where(
                user => user.cardID == userName && user.Password == password
                );
            if (curentUser.Count() == 1)
            {
                User user = curentUser.First();
                Console.WriteLine("chao {0}", user.userName);
                do
                {
                    displayMenu();
                    select = Convert.ToInt32(Console.ReadLine());
                    switch (select)
                    {
                        case 1:

                            
                            Console.WriteLine("Moi ban nhap so tien");
                            num = Convert.ToInt32(Console.ReadLine());
                            if (num > user.Surplus)
                            {
                                Console.WriteLine("So tien muon chuyen vuot qua so du");
                            }
                            else if (num < 300 && num % 5 == 0)
                            {
                                Console.WriteLine("Rut tien thanh cong");
                                user.Surplus -= num;
                                Console.WriteLine("So du hien tai:{0}", user.Surplus);
                            }
                            else
                            {
                                Console.WriteLine("So tien phai nho hon 300 hoac la boi cua 5");
                            }
                            break;
                        case 2:
                            Console.WriteLine("tai khoan hien tai dang co: " + surplus);
                            Console.WriteLine("nhap gia tri can chuyen");
                            num = Convert.ToInt32(Console.ReadLine());
                            var targerUser = Bank.Where(
                                user => user.cardID == num
                                );
                            if (targerUser.Count() > 0)
                            {
                                User target = targerUser.First();
                                Console.WriteLine("tai khoan dich {0}", target.userName);
                                Console.WriteLine("nhap so tien can chuyen:");
                                num = Convert.ToInt32(Console.ReadLine());
                                if (num > user.Surplus)
                                {
                                    Console.WriteLine("So tien muon chuyen vuot qua so du");
                                }
                                else if (num < 300 && num % 5 == 0)
                                {
                                    Console.WriteLine("Chuyen tien thanh cong");
                                    user.Surplus -= num;
                                    target.Surplus += num;
                                    Console.WriteLine("So du hien tai:{0}", user.Surplus);
                                }
                                else
                                {
                                    Console.WriteLine("So tien phai nho hon 300 hoac la boi cua 5");
                                }

                            }
                            else
                            {
                                Console.WriteLine("So tai khoan khong hop le");
                            }
                            break;

                        case 3:
                            Console.WriteLine("So du cua ban la: {0}", user.Surplus);
                            break;
                        default:
                            Console.WriteLine("Ban da nhap sai lua chon");
                            break;
                    }
                    Console.WriteLine("Ban co muon tiep tuc khong?[0/1]");
                    isContinue = Convert.ToInt32(Console.ReadLine());
                    if (isContinue == 0)
                    {
                        Console.WriteLine("Chao va hen gap lai");
                        break;
                    }

                    Console.WriteLine("ban co muon tiep tuc? 0.khong  1.co");
                    isContinue = Convert.ToInt32(Console.ReadLine());
                    if (isContinue == 0)
                    {
                        Console.WriteLine("xin cam on va hen gap lai");
                        break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("thong tin tai khoan mat khau khong dung,vui long thu lai");
                count++;
            }
        }while (count <= 3);
    }
        
}
