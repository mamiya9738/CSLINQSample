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
        new A(){ Key = 1 , No = 20 ,Name = "Name1'",},
        new A(){ Key = 2 , No = 20 ,Name = "Name2'",},
        new A(){ Key = 3 , No = 20 ,Name = "Name3'",},
        new A(){ Key = 4 , No = 40 ,Name = "Name4'",},
        new A(){ Key = 5 , No = 40 ,Name = "Name5'",},
};

// Inner Join
var listTest =  ( from right in listA
             // Inner Join
             join left in listB
            on right.Key equals left.Key
            select right).ToList();

// デバッグ出力
// Inner Join:,Name1,Name2,Name3,Name4,Name5
Console.Write("Inner Join:");
listTest.ForEach(a => Console.Write(","+a.Name));
Console.WriteLine("");


// Left Join
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

//GroupBy
var groupQuery = 
        from a in listA
        group a by a.No into aGroup
        select aGroup;

// デバッグ出力
// group :,20[ ,Name1,Name3,Name5,Name7,Name9 ],30[ ,Name2,Name4,Name6,Name8 ]
Console.Write("group :");
foreach(var a in groupQuery)
{
        Console.Write(","+ a.Key + "[ ");
        foreach(var b in a)
        {
                Console.Write(","+ b.Name);                
        }
        Console.Write(" ]");
}
Console.WriteLine("");

var orderbyQuery = 
        from a in listA
        orderby a.No
        select a;

// デバッグ出力
// orderby :[20,Name1][20,Name3][20,Name5][20,Name7][20,Name9][30,Name2][30,Name4][30,Name6][30,Name8]
Console.Write("orderby :");
foreach (var a in orderbyQuery)
{
        Console.Write("[" +a.No + ","+ a.Name + "]");                        
}
Console.WriteLine("");

// 複問合せ
var query = from a in groupQuery
            join b in listB
            on new { No = a.Key, Key = 1} equals new {No = b.No,Key =b.Key}
            select a;

// デバッグ出力
// groupSelect :,20[ ,Name1,Name3,Name5,Name7,Name9 ]
Console.Write("groupSelect :");
foreach(var a in query)
{
        Console.Write(","+ a.Key + "[ ");
        foreach(var b in a)
        {
                Console.Write(","+ b.Name);                
        }
        Console.Write(" ]");
}
Console.WriteLine("");



// switch文で型比較

List<A> aa = new List<A>(){
        new A(){ Key = 1,Name="aaa1",No =10},
        new B(){ Key = 2,Name="bbb1",No =30,Type = "Type-B1"},
        new A(){ Key = 3,Name="aaa2",No =11},
        new B(){ Key = 4,Name="bbb2",No =31,Type = "Type-B2"},
        new A(){ Key = 5,Name="aaa3",No =12},
        new B(){ Key = 6,Name="bbb3",No =32,Type = "Type-B2"},
};

foreach(var item in aa)
{
        var msg = item switch
        {
                // switch式でクラスの判定ができる。
                // 親を上に書くと全て親でマッチする
                B => ((B)item).Type,
                _ => item.Name,
        };
        Console.WriteLine(msg);
}



