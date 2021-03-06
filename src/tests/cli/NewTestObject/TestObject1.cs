/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Apache.Geode.Client.Tests
{
  using Apache.Geode.Client;
  public class TestObject1
    : IGeodeSerializable
  {
    private string name;
    private byte[] arr;
    private int identifire;

    public TestObject1()
    {
    }
    public TestObject1(string objectName, int objectIdentifire)
    {
      name = objectName;
      byte[] arr1 = new byte[1024 * 4];
      arr = arr1;
      //Array.ForEach(arr, 'A');
      identifire = objectIdentifire;
    }
    public UInt32 ObjectSize
    {
      get
      {
        return 0;
      }
    }
    public UInt32 ClassId
    {
      get
      {
        return 0x1F;
      }
    }
    public IGeodeSerializable FromData(DataInput input)
    {
      arr = input.ReadBytes();
      name = (string)input.ReadObject();
      identifire = input.ReadInt32();
      return this;
    }
    public void ToData(DataOutput output)
    {
      output.WriteBytes(arr);
      output.WriteObject(name);
      output.WriteInt32(identifire);
    }

    public static IGeodeSerializable CreateDeserializable()
    {
      return new TestObject1();
    }
  }
}
