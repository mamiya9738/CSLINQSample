// テストデータA
var listA = new List<A>(){
        new A(){ Key = 1, Name = "Name1",},
        new A(){ Key = 2 , Name = "Name2",},
        new A(){ Key = 3 , Name = "Name3",},
        new A(){ Key = 4 , Name = "Name4",},
        new A(){ Key = 5 , Name = "Name5",},
        new A(){ Key = 6 , Name = "Name6",},
        new A(){ Key = 7 , Name = "Name7",},
        new A(){ Key = 8 , Name = "Name8",},
        new A(){ Key = 9 , Name = "Name9",},
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

