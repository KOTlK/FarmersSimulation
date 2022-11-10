using Game.Runtime.Resources;
using NUnit.Framework;
using UnityEngine;

public class StorageTest
{
    [Test]
    public void ResourcesCompared()
    {
        var storage = new ResourceStorage(1000);

        storage.Put(Resource.Copper, 10);
        storage.Put(Resource.Iron, 10);
        storage.Put(Resource.Gold, 15);
        storage.Put(Resource.Silver);
        

        Assert.True(storage.Count(Resource.Copper) == 10);
        Assert.True(storage.Count(Resource.Iron) == 10);
        Assert.True(storage.Count(Resource.Gold) == 15);
        Assert.True(storage.Count(Resource.Silver) == 1);
        
        Assert.True(storage.Count(new[]
        {
            Resource.Copper,
            Resource.Iron
        }) == 20);
        
        Assert.True(storage.Count(new[]
        {
            Resource.Copper,
            Resource.Iron,
            Resource.Gold
        }) == 35);
        
        Assert.True(storage.Count(new[]
        {
            Resource.Copper,
            Resource.Iron,
            Resource.Gold,
            Resource.Silver
        }) == 36);
    }

    [Test]
    public void CoupleResourcesRemoved()
    {
        var storage = new ResourceStorage(1000);

        storage.Put(Resource.Iron, 10);
        storage.Put(Resource.Gold, 5);
        storage.Take(new[]
        {
            (Resource.Iron, 10),
            (Resource.Gold, 5),
        });
        Assert.True(storage.Count(new []
        {
            Resource.Iron,
            Resource.Gold
        }) == 0);

        storage.Put(Resource.Iron, 15);
        storage.Put(Resource.Gold, 10);
        storage.Put(Resource.Silver, 30);

        storage.Take(new[]
        {
            (Resource.Iron, 10),
            (Resource.Gold, 10),
        });
        
        Assert.True(storage.Count(new []
        {
            Resource.Iron,
            Resource.Gold,
            Resource.Silver
        }) == 35);
    }

    [Test]
    public void ResourceRemoved()
    {
        var storage = new ResourceStorage(1000);
        
        storage.Put(Resource.Copper, 5);
        storage.Take(Resource.Copper, false, 5);
        Assert.True(storage.Count(Resource.Copper) == 0);
    }

    [Test]
    public void AllResourcesRemoved()
    {
        var storage = new ResourceStorage(1000);

        storage.Put(Resource.Copper);
        storage.Take(Resource.Copper, true);
        Assert.True(storage.Count(Resource.Copper) == 0);
    }

    [Test]
    public void AllResourcesTaken()
    {
        var storage = new ResourceStorage(1000);

        storage.Put(Resource.Copper, 100);
        storage.Put(Resource.Iron, 100);

        storage.Take(new[]
        {
            Resource.Copper,
            Resource.Iron
        });
        Assert.True(storage.Count(new []
        {
            Resource.Copper,
            Resource.Iron
        }) == 0);
    }

    [Test]
    public void ResourcesTransfered()
    {
        var storage = new ResourceStorage(1000);
        var secondStorage = new ResourceStorage(1000);

        storage.Put(Resource.Copper, 100);
        storage.Take(Resource.Copper, true).Transfer(secondStorage);
        Assert.True(secondStorage.Count(Resource.Copper) == 100);


        storage.Put(Resource.Iron, 10);
        storage.Put(Resource.Gold, 30);
        storage.Take(new[]
        {
            (Resource.Iron, 10),
            (Resource.Gold, 30)
        }).Transfer(secondStorage);
        Assert.True(secondStorage.Count(new Resource[]
        {
            Resource.Iron,
            Resource.Gold,
            Resource.Copper
        }) == 140);
    }

}
