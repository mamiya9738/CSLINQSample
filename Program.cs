// テストデータA
var listA = new List<A>(){
        new A(){ Key = 1, Name = "Name1",},
        new A(){ Key = 2 , Name = "Name2",},
        new A(){ Key = 3 , Name = "Name3",},
        new A(){ Key = 4 , Name = "Name4",},
        new A(){ Key = 5 , Name = "Name5",},
};

// テストデータB
var listB = new List<A>(){
        new A(){ Key = 1 , Name = "Name1'",},
        new A(){ Key = 2 , Name = "Name2'",},
        new A(){ Key = 3 , Name = "Name3'",},
        new A(){ Key = 4 , Name = "Name4'",},
        new A(){ Key = 5 , Name = "Name5'",},
        new A(){ Key = 6 , Name = "Name6'",},
        new A(){ Key = 7 , Name = "Name7'",},
        new A(){ Key = 8 , Name = "Name8'",},
        new A(){ Key = 9 , Name = "Name9'",},
};

// A And B かつ 3の倍数の値のみを取得する
var listTest =  ( from right in listA
             // Inner Join
             join left in listB
            on right.Key equals left.Key
            where right.Key % 3 == 0
            select right).ToList();

// デバッグ出力
// Test3

foreach(var obj in listTest)
{
    Console.WriteLine(obj.Name);
}

// A And B かつ 3の倍数の値のみを取得する
var listTest2 =  ( from right in listA
             // Left Join
             join left in listB
            on right.Key equals left.Key into tJoin
             from tj in tJoin.DefaultIfEmpty() 
            where tj.Key % 3 == 0
            select tj).ToList();

// デバッグ出力
// Test3
// Test3'

foreach(var obj in listTest2)
{
    Console.WriteLine(obj.Name);
}
