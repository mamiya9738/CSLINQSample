// テストデータA
var listA = new List<A>(){
        new A(){ Key = 1 , No = 20 , Name = "Name1",},
        new A(){ Key = 2 , No = 30 , Name = "Name2",},
        new A(){ Key = 3 , No = 20 , Name = "Name3",},
        new A(){ Key = 4 , No = 30 , Name = "Name4",},
        new A(){ Key = 5 , No = 20 , Name = "Name5",},
        new A(){ Key = 6 , No = 30 , Name = "Name6",},
        new A(){ Key = 7 , No = 20 , Name = "Name7",},
        new A(){ Key = 8 , No = 30 , Name = "Name8",},
        new A(){ Key = 9 , No = 20 , Name = "Name9",},
};

// テストデータB
var listB = new List<A>(){
        new A(){ Key = 1 , Name = "Name1'",},
        new A(){ Key = 2 , Name = "Name2'",},
        new A(){ Key = 3 , Name = "Name3'",},
        new A(){ Key = 4 , Name = "Name4'",},
        new A(){ Key = 5 , Name = "Name5'",},
};

// A And B かつ 3の倍数の値のみを取得する
var listTest =  ( from right in listA
             // Inner Join
             join left in listB
            on right.Key equals left.Key
        //    where right.Key % 3 == 0
            select right).ToList();

// デバッグ出力
// Inner Join:,Name1,Name2,Name3,Name4,Name5
Console.Write("Inner Join:");
listTest.ForEach(a => Console.Write(","+a.Name));
Console.WriteLine("");

// A And B かつ 3の倍数の値のみを取得する
var listTest2 =  ( from right in listA
             // Left Join
             join left in listB
            on right.Key equals left.Key into tJoin
             from tj in tJoin.DefaultIfEmpty() 
        //    where tj.Key % 3 == 0
            select right).ToList();



// デバッグ出力
// Left Join:,Name1,Name2,Name3,Name4,Name5,Name6,Name7,Name8,Name9
Console.Write("Left Join:");
listTest2.ForEach(a => Console.Write(","+a.Name));
Console.WriteLine("");

var group = 
        from a in listA
        group a by a.No into aGroup
        select aGroup;

// デバッグ出力
// group :,20[ ,Name1,Name3,Name5,Name7,Name9 ],30[ ,Name2,Name4,Name6,Name8 ]
Console.Write("group :");
foreach(var a in group)
{
        Console.Write(","+ a.Key + "[ ");
        foreach(var b in a)
        {
                Console.Write(","+ b.Name);                
        }
        Console.Write(" ]");
}
Console.WriteLine("");


var orderby = 
        from a in listA
        orderby a.No
        select a;

// デバッグ出力
// orderby :[20,Name1][20,Name3][20,Name5][20,Name7][20,Name9][30,Name2][30,Name4][30,Name6][30,Name8]
Console.Write("orderby :");
foreach (var a in orderby)
{
        Console.Write("[" +a.No + ","+ a.Name + "]");                        
}
Console.WriteLine("");
