#pragma once

#ifndef GEODE_POOLEDBASEPOOL_H_
#define GEODE_POOLEDBASEPOOL_H_

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

#include <geode/geode_globals.hpp>
#include <geode/SharedPtr.hpp>
#include "PooledBase.hpp"
#include <deque>

#include "util/concurrent/spinlock_mutex.hpp"

namespace apache {
namespace geode {
namespace client {

using util::concurrent::spinlock_mutex;

class CPPCACHE_EXPORT PooledBasePool {
  spinlock_mutex m_poolLock;
  std::deque<PooledBase*> m_pooldata;

 public:
  PooledBasePool() : m_poolLock(), m_pooldata() {}

  ~PooledBasePool();

  void returnToPool(PooledBase* poolable);

  PooledBase* takeFromPool();

  void clear();
};
}  // namespace client
}  // namespace geode
}  // namespace apache

#endif  // GEODE_POOLEDBASEPOOL_H_
